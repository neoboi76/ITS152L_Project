using ItemDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITS152L_Project.Repositories.Interfaces
{
    public interface IPasswordResetTokenRepository
    {
        Task CreateTokenAsync(int userId, string token, int expiryMinutes);
        Task<IEnumerable<PasswordResetToken>> GetAllTokensAsync();
        Task MarkTokenAsUsedAsync(int tokenId);
        Task DeleteExpiredTokensAsync();
    }
}
