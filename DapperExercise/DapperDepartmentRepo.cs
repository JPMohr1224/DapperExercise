using System;
using System.Data;
using Dapper;

namespace DapperExercise
{
	public class DapperDepartmentRepo : IDepartmentRepo
	{
		private readonly IDbConnection _conn;

		public DapperDepartmentRepo(IDbConnection conn)
		{
			_conn = conn;
		}

        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department> ("SELECT * FROM Departments;");
        }

        public void InsertDepartment(string NewDepartmentName)
        {
            _conn.Execute("INSERT INTO Departments (Name) VALUES (@departmentName);",
                new {departmentName = NewDepartmentName});
        }
    }
}

