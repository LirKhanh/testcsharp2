using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train2
{
    internal class Employee: Person
    {
        private int id { get; set; }
        private string pos {  get; set; }
        private long sal {  get; set; }
        public Employee() { }
        public Employee(string name, string address, string pos, long sal, int id) : base(name, address) { 
            this.setName(name);
            this.setAddress(address);
            this.pos = pos;
            this.sal = sal;
            this.id = id;
        } 
        public int calCoel(string pos)
        {
            switch (pos.ToLower())
            {
                case "giám đốc":
                    return 10;
                case "trưởng phòng":
                case "phó giám đốc":
                    return 6;
                case "phó phòng":
                    return 4;
                default:
                    return 2;
            }
        }
        public void input()
        {
            Console.Write("Nhap ID cua nhan vien:");
            id = Convert.ToInt32(Console.ReadLine());  
            Console.Write("Nhập tên của nhân viên:");
            setName(Console.ReadLine());
            Console.Write("Nhập địa chỉ của nhân viên:");
            setAddress(Console.ReadLine());
            Console.Write("Nhập chức vụ của nhân viên:");
            pos = Console.ReadLine();
            Console.Write("Nhập lương của nhân viên:");
            sal = Convert.ToInt32(Console.ReadLine());

        }
        public void output() {
            Console.WriteLine($"{id,-10}{getName(),-20}{getAddress(),-15}{pos,-20}{calCoel(pos),-10}{sal,-15}");
        }
        public static void menu()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("0.Thoat chuong trinh");
            Console.WriteLine("1.Them nhan vien");
            Console.WriteLine("2.Xoa nhan vien");
            Console.WriteLine("3.Sap xep nhan vien theo ten(/he so luong)");
            Console.WriteLine("4.Hien thi danh sach nhan vien");
            Console.WriteLine("---------------------");
        }
        public void addEm(List<Employee> list)
        {
            Employee emp = new Employee();
            emp.input();
            if (list != null)
            {
                if (list.Find(e => e.id == emp.id) == null)
                {
                    list.Add(emp);
                    Console.WriteLine("Them thanh cong");
                }
                else
                {
                    Console.WriteLine("ID da ton tai, vui long nhap lai");
                }
            }
            else
            {
                list.Add(emp);
                Console.WriteLine("Them thanh cong");
            }
        }
        public void delEm(List<Employee> list)
        {
            Console.WriteLine("Nhap ID ban muon xoa:");
            string s = Console.ReadLine();
            Employee emp = list.FirstOrDefault(e => e.id == Convert.ToInt32(s));
            if (emp != null) { 
                list.Remove(emp);
                Console.WriteLine("Xoa thanh cong");
            }
            else
            {
                Console.WriteLine("ID khong ton tai de xoa");
            }
        } 
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try 
            {
                List<Employee> list = new List<Employee>();
                int choice = -1;
                while (choice != 0) {
                    menu();
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Chuong trinh ket thuc");
                            break;
                        case 1:
                            Employee emp1 = new Employee();
                            emp1.addEm(list);
                            break;
                        case 2:
                            Employee emp2 = new Employee();
                            emp2.delEm(list);
                            break;
                        case 3:
                            list.Sort((emp3, emp4) =>
                            {
                                int comp = emp3.getName().CompareTo(emp4.getName());
                                if (comp == 0)
                                {
                                    return emp3.calCoel(emp3.pos).CompareTo(emp4.calCoel(emp4.pos));
                                }
                                else 
                                {
                                    return comp;
                                }
                            });
                            break;
                        case 4:
                            foreach ( Employee e in list)
                            {
                                e.output();
                            }
                            break;
                        default:
                            Console.WriteLine("Lua chon khong hop le");
                            break;
                    }
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);   
            }
        }
    }
}
