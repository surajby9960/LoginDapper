using LoginDapper.Model;

namespace LoginDapper.Repositories.Interfaces
{
    public interface IRegisterRepository
    {
        public Task<IEnumerable<Register>> ShowAll();
        public Task<Register> GetByEmail(string email);
        public Task<int> NewRegister(NewRegister register);
        public Task<string> Login(string email, Login login);
        public Task<string> UpdatePassword(string email, string password);
        public Task Delete(int id);
    }
}
