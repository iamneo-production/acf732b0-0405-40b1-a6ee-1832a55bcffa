using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;

namespace dotnetapp.Core
{
    public class Auth : IAuth
    {
        private readonly yogaTrainerContext TrainerContext;
        private readonly IConfiguration configuration;
        public Auth(yogaTrainerContext trainerContext, IConfiguration configuration)
        {
            TrainerContext = trainerContext;
            this.configuration = configuration;
        }
        public ResponseModel GenerateToken(LoginModel loginModel)
        {
            try
            {
                var userExists = TrainerContext.userModels.FirstOrDefault(x => x.Email.ToLower() == loginModel.Email.ToLower() && x.Password.ToLower() == loginModel.Password.ToLower());
                if (userExists != null)
                {
                    var role = TrainerContext.userModels.Where(x => x.Email == loginModel.Email).Select(y => y.UserRole).First();
                    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                        {
                        new Claim(ClaimTypes.Email,loginModel.Email),
                        //new Claim("password",loginModel.Password),
                        new Claim("role",role)

                    };

                    var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

                    var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);


                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Message = generatedToken.ToString();
                    responseModel.Status = true;
                    return responseModel;
                }
                ResponseModel response = new ResponseModel();
                response.ErrorMessage = $"No user found with username";
                response.Status = true;
                return response;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ResponseModel> RegisterUser(UserModel userModel)
        {
            ResponseModel responseModel = null;
            try
            {
                var response = await TrainerContext.userModels.AddAsync(userModel);
                await TrainerContext.SaveChangesAsync();
                if (response != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Message = "User registered";
                    responseModel.Status = true;
                    return responseModel;
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.ErrorMessage = "User registration failled";
                    responseModel.Status = false;
                    return responseModel;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
