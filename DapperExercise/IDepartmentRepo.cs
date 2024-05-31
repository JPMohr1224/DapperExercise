using System;
namespace DapperExercise
{
	public interface IDepartmentRepo
	{
		public IEnumerable<Department> GetAllDepartments();
		public void InsertDepartment(string NewDepartmentName);
	}
}

