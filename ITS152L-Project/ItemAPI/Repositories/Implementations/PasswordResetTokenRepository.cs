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

        public async Task<IEnumerable<PasswordResetToken>> GetAllTokensAsync()
        {
            return await _context.PasswordResetTokens
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task MarkTokenAsUsedAsync(int tokenId)
        {
            var token = await _context.PasswordResetTokens.FindAsync(tokenId);
            if (token != null)
            {
                token.IsUsed = true;
                await _context.SaveChangesAsync();
            }
        }

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
