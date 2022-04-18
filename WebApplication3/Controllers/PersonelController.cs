using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using WebApplication3.Model;
using WebApplication3.Repository;
using AutoMapper;



namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {


        private readonly IMapper _mapper;
        public PersonelController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [Route("/api/personel/personeldto")]
        [HttpGet]
        public PersonelDto GetPersonelDto(Personel personels)
        {

            var personel = new Personel
            {

                Name = "ASLI",
                Surname = "aslı",
                Department = "aslı",
                Age = 18,
                Salary = 2222
            };

            var personelDto = _mapper.Map<PersonelDto>(personel);
            return personelDto;
        }

       
    
    List<Personel> personels = new List<Personel>();
        NpgsqlConnection connect = new NpgsqlConnection("Server=localHost;Port=5432;Database=postgres;User Id=postgres;Password=1");



        [HttpGet]
        public List<Personel> Get()
        {

            try
            {
                connect.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM personel", connect);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    personels.Add(new Personel { Id = (Int64)dataReader["id"], Name = (string)dataReader["name"], Surname = (string)dataReader["surname"], Department = (string)dataReader["department"], Age = (Int64)dataReader["age"], Salary = (Int64)dataReader["salary"] });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connect.Close();

            }
            return personels;
        }

        [HttpPost]
        public Personel Post([FromBody]Personel personel)
        {


            try
            {
                connect.Open();
                string sql = $@"insert into personel (name, surname, department, age, salary) values ('{personel.Name}', '{personel.Surname}', '{personel.Department}', {Convert.ToInt64(personel.Age)}, {Convert.ToInt64(personel.Salary)})";
                NpgsqlCommand command = new NpgsqlCommand(sql, connect);
                command.ExecuteNonQuery();
                personels.Add(personel);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connect.Close();
            }
            return personel;
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {
                connect.Open();
                string sql = $@"DELETE FROM personel where id = {id} ";
                NpgsqlCommand command = new NpgsqlCommand(sql, connect);
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        [HttpPut("{id}")]
        public void Update([FromBody]Personel personel, int id)
        {

            try
            {
                connect.Open();
                string param = "";


                    
                    if (personel.Name != null && personel.Name != "")
                    {
                        param += @$"Name = '{personel.Name}',";
                    }
                    else
                    {
                        param += "";
                    }


                if (personel.Surname != null && personel.Surname != "")
                {
                    param += $@"Surname = '{personel.Surname}',";
                }
                else
                {
                    param += "";
                }

                if (personel.Department != null && personel.Department != "")
                {
                    param += $@"Department = '{personel.Department}',";
                }
                else
                {
                    param += "";
                }

                if (personel.Salary != null && personel.Salary.ToString() != "")
                {
                    param += $@"Salary = {personel.Salary},";
                }
                else
                {
                    param += "";
                }

                if (personel.Age != null && personel.Age.ToString() != "")
                {
                    param += $@"Age = {personel.Age},";
                }
                else
                {
                    param += "";
                }


                // param = personel.Name != null && personel.Name != "" ? param += @$"Name = '{personel.Name}'," : param += "";
                //param = personel.Surname != null && personel.Surname != "" ? param += $@"Surname = '{personel.Surname}'," : param += "";
                //param = personel.Department != null && personel.Department != "" ? param += $@"Department = '{personel.Department}'," : param += "";
                //param = personel.Salary != null && personel.Salary.ToString() != "" ? param += $@"Salary = {personel.Salary}," : param += "";
                //param = personel.Age != null && personel.Age.ToString() != "" ? param += $@"Age = {personel.Age}," : param += "";

                
                string sql = $@"UPDATE personel SET {param.Remove(param.Length-1)} where id = {id}";

                Console.WriteLine(sql);
                NpgsqlCommand command = new NpgsqlCommand(sql, connect);
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connect.Close();
            }
        }
    }
  
}