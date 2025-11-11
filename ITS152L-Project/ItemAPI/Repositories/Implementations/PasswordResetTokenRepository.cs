/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * PasswordResetTokenRepository class. Deals with password reset token related
 * database operations
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS152L_Project.Data;
using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITS152L_Project.Repositories.Implementations
{
    public class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {
        private readonly ItemApiContext _context;

        public PasswordResetTokenRepository(ItemApiContext context)
        {
            _context = context;
        }

        //Creates reset token
        public async Task CreateTokenAsync(int userId, string token, int expiryMinutes)
        {
            var newToken = new PasswordResetToken
            {
                UserId = userId,
                Token = token,
                Expiry = DateTime.UtcNow.AddMinutes(expiryMinutes),
                IsUsed = false
            };
            _context.PasswordResetTokens.Add(newToken);
            await _context.SaveChangesAsync();
        }

        //Retrieves all reset tokens
        public async Task<IEnumerable<PasswordResetToken>> GetAllTokensAsync()
        {
            return await _context.PasswordResetTokens
                .AsNoTracking()
                .ToListAsync();
        }

        //Expires (or marks) a token as used when the user successfully uses it
        public async Task MarkTokenAsUsedAsync(int tokenId)
        {
            var token = await _context.PasswordResetTokens.FindAsync(tokenId);
            if (token != null)
            {
                token.IsUsed = true;
                await _context.SaveChangesAsync();
            }
        }

        //Purge all reset tokens that are past expiration date
        public async Task DeleteExpiredTokensAsync()
        {
            var expiredTokens = await _context.PasswordResetTokens
                .Where(t => t.Expiry <= DateTime.UtcNow || t.IsUsed)
                .ToListAsync();

            _context.PasswordResetTokens.RemoveRange(expiredTokens);
            await _context.SaveChangesAsync();
        }
    }
}
