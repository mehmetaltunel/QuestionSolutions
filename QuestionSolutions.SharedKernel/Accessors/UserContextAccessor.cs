using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace QuestionSolutions.SharedKernel.Accessors
{
    public class UserContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public UserContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool   IsAuthenticated     => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        public string UserId           => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
       // public string ErpRoleAssignmentId => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
    }
}