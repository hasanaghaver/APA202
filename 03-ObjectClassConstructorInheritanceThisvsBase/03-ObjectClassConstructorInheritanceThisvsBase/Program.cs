namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new("Huseyn","Rzayev",19,"huseyn@gmail.com","100000","13","MQ",88.5,2);
            Student student2 = new("Hesen","Agaverdiyev",20,"hasan@gmail.com","100001","19","ITT",92.0,3);
            Student student3 = new("Mehdi","Qurbanov",18,"mehdi@gmail.com","100034","4","PA",68.5,1);

            Teacher teacher1 = new("Kamran", "Ebilov", 46, "kamran@gmail.com", "104743", "KA", "Informatika", 1500, 15);
            Teacher teacher2 = new("Eliebbas", "Haxiyev", 78, "eliabbas@gmail.com", "147374", "RVSI", "Riyaziyyat", 1450, 8);

            Administrator administrator1 = new("Zefer", "Eliyev", 56, "zefer@gmail.com", "173379", "Dekan", "Informasiya texnologiyalari", 5);

            //telebeler ucun
            student1.ShowStudentInfo();
            Console.WriteLine("Teqaud:"+ student1.CalculateScholarship());
            Console.WriteLine("---------------------------------------------------------");
            student2.ShowStudentInfo();
            Console.WriteLine("Teqaud:" + student2.CalculateScholarship());
            Console.WriteLine("---------------------------------------------------------");
            student3.ShowStudentInfo();
            Console.WriteLine("Teqaud:" + student3.CalculateScholarship());
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------");

            //Muellimler ucun
            teacher1.ShowTeacherInfo();
            teacher1.CalculateSalary();
            Console.WriteLine("---------------------------------------------------------");
            teacher2.ShowTeacherInfo();
            teacher2.CalculateSalary();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------");

            // Admin ucun
            administrator1.ShowAdminInfo();
            administrator1.GrantAccess(student2);


        }
    }
}
