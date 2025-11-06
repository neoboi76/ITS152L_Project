using ItemDataLibrary.Models;
using ItemDataLibrary.Security;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly ItemApiContext _context;
        private readonly IPasswordResetTokenRepository _tokenRepository;
        private readonly SecureEmailService _emailService;

        public PasswordResetController(
            ItemApiContext context,
            IPasswordResetTokenRepository tokenRepository,
            SecureEmailService emailService)
        {
            _context = context;
            _tokenRepository = tokenRepository;
            _emailService = emailService;
        }

        /// <summary>
        /// Check if email exists and return user
        /// </summary>
        [HttpGet("check-email/{email}")]
        public async Task<ActionResult<UserModel>> CheckEmailExists(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == email);

            if (user == null)
            {
                return NotFound("Email not found in system");
            }

            return Ok(user);
        }

        /// <summary>
        /// Generate and send verification code
        /// </summary>
        [HttpPost("send-code/{userId}")]
        public async Task<IActionResult> SendVerificationCode(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                bool sent = await _emailService.SendVerificationCodeAsync(user);

                if (sent)
                {
                    return Ok("Verification code sent successfully");
                }
                else
                {
                    return StatusCode(500, "Failed to send verification code");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Verify code and mark as used
        /// </summary>
        [HttpPost("verify-code")]
        public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeRequest request)
        {
            try
            {
                bool isValid = await _emailService.VerifyCodeAsync(request.UserId, request.Token);

                if (isValid)
                {
                    return Ok("Code verified successfully");
                }
                else
                {
                    return BadRequest("Invalid, expired, or already used code");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Reset password after verification
        /// </summary>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                var user = await _context.Users.FindAsync(request.UserId);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Validate password
                if (!PasswordHasher.IsPasswordValid(request.NewPassword, out string errorMessage))
                {
                    return BadRequest(errorMessage);
                }

                // Hash and save new password
                user.Password = PasswordHasher.HashPassword(request.NewPassword);
                await _context.SaveChangesAsync();

                return Ok("Password reset successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Cleanup expired tokens (can be called periodically)
        /// </summary>
        [HttpPost("cleanup-expired")]
        public async Task<IActionResult> CleanupExpiredTokens()
        {
            try
            {
                await _emailService.CleanupExpiredTokensAsync();
                return Ok("Expired tokens cleaned up successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

    // Request models
    public class VerifyCodeRequest
    {
        public int UserId { get; set; }
        public string Token { get; set; } = null!;
    }

    public class ResetPasswordRequest
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; } = null!;
    }
}