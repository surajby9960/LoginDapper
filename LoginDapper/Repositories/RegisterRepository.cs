using LoginDapper.Context;
using LoginDapper.Model;
using LoginDapper.Repositories.Interfaces;
using Dapper;

namespace LoginDapper.Repositories
{
    public class RegisterRepository: IRegisterRepository
    {
        private readonly DapperContext context;
        public RegisterRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<Register> GetByEmail(string email)
        {
            var qry = "select * from Register where emailId=@email";
            using(var connection=context.CreateConnection())
            {
                var obj=await connection.QuerySingleAsync<Register>(qry, new {email=email});
                return obj;
            }
        }

       

        public async Task<int> NewRegister(NewRegister register)
        {

            var qry = "insert into Register(emailId,pwd)values(@emailId,@pwd)";
            using (var connection=context.CreateConnection())
            {
                var res=await connection.ExecuteAsync(qry,register);
                return res;
            }
        }

        public async Task<IEnumerable<Register>> ShowAll()
        {
            var qry = "select * from Register";
            using (var conn=context.CreateConnection())
            {
                var obj=await conn.QueryAsync<Register>(qry);
                return obj.ToList();
            }
        }
        public async Task<string> Login(string email, Login login)
        {
            var qry = "select * from Register where emailId=@email";
            using(var conn=context.CreateConnection())
            {
                var obj = await conn.QueryFirstOrDefaultAsync<Login>(qry, new { email = email });
                if (obj != null)
                {
                    if (obj.pwd == login.pwd)
                        return ("Login succesfulyy !!");
                    else
                        return ("Password is Incorrect");
                }
                else
                {
                    return ("Record not found");
                }
                
            }
        }

        public async Task<string> UpdatePassword(string email, string password)
        {
            var qry = "update Register set pwd=@pwd where emailId=@email ";
            var para = new DynamicParameters();
            para.Add("pwd", password);
            para.Add("email",email);
            using(var connection=context.CreateConnection())
            {

                var res = await connection.ExecuteAsync(qry, para);
                if (res != 0)
                    return ("updated succesfully!!!");
                return ("not Found!!");
            }
        }

        public async Task Delete(int id)
        {
           
            using(var conn=context.CreateConnection())
            {
                await conn.ExecuteAsync("delete from Register where rid=@id", new { id });
            }
        }
    }
}
