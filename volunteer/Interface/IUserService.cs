using volunteer.DTO;

using volunteer.Service;


namespace volunteer.Services 
{
	public interface IUserService
	{
		Task<UserResponse> RegiserUserAsync(RegisterDTO registerDTO);
		Task<UserResponse> LoginAsync(LoginDTO loginDTO);
	}
}
