/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Interface for the IPasswordResetTokenRepository. Promotes dependency injection
 * and loosely coupled relationships
 **/

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
