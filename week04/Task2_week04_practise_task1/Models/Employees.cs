﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_week04_practise_task1.Models
{
    public class Employee
    {
        string _name, _surname, _username;
        byte _age, _flags; // 000

        public string Username
        {
            get => _username;
            set
            {
                if (value == "update" && this._flags == 3) // 011 = 3
                {
                    this._username = this.Name + "_" + this.Surname;
                }
                else
                {
                    this._username = "none";
                }
            }
        }
        public string Name
        {
            get => _name; 
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    value = value.Trim();
                    this._name = Char.ToUpper(value[0]) + value.Substring(1);
                    this._flags |= 1; // 001
                }
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    value = value.Trim();
                    this._surname = Char.ToUpper(value[0]) + value.Substring(1);
                    this._flags |= 2; // 010
                }
            }
        }
        public byte Age
        {
            get => this._age;
            set
            {
                if (value > 0) this._age = value;
                else this._age = 1;
            }
        }

        public Employee(string Name, string Surname, byte Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Username = "update";
        }

        public override string ToString()
        {
            return this.Username + " at age " + this.Age;
        }
    }
    public class Company
    {
        string _companyName;
        Employee[] _employees;
        int _length = 0;


        public Company(string CompanyName)
        {
            this._companyName = CompanyName;
            this._employees = new Employee[0];
        }

        public override string ToString()
        {
            return this._companyName;
        }

        public void AddUser(Employee user)
        {
            Employee[] newArray = new Employee[this._length + 1];

            for (int i = 0; i < this._length; i++)
            {
                newArray[i] = this._employees[i];
            }

            newArray[this._length] = new Employee(user.Name, user.Surname, user.Age);
            this._length++;
            this._employees = newArray;
        }
        public void RemoveUser(string user)
        {
            int RemoveIndex = this.GetUserInt(user);

            if (RemoveIndex >= 0)
            {
                int index = 0;
                Employee[] newArray = new Employee[this._employees.Length - 1];

                for (int i = 0; i < newArray.Length; i++)
                {
                    if (RemoveIndex == i)
                    {
                        continue;
                    }
                    newArray[index] = this._employees[i];
                    index++;
                }

                this._employees = newArray;
                this._length--;
            }
            else
            {
                Console.WriteLine(user + " Not founded.");
            }
        }
        public int GetUserInt(string user)
        {
            if (this._length > 0)
            {
                for (int i = 0; i < this._employees.Length; i++)
                {
                    if (this._employees[i].Username == user)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
        public Employee GetUser(string user)
        {
            int index = this.GetUserInt(user);
            if (index >= 0)
            {
                return new Employee(this._employees[index].Name, this._employees[index].Surname, this._employees[index].Age);
            }

            Console.WriteLine(user + " Not founded.");
            return null;
        }
        public Employee[] GetAllUsers()
        {
            Employee[] ReturnValue = new Employee[this._employees.Length];

            for (int i = 0; i < this._employees.Length; i++)
            {
                ReturnValue[i] = new Employee(this._employees[i].Name, this._employees[i].Surname, this._employees[i].Age);
            }

            return ReturnValue;
        }
        public void UpdateUser(string user)
        {
            int index = this.GetUserInt(user);
            bool isInterface;
            if (index >= 0)
            {
                do
                {
                    Console.WriteLine("1. Update Name");
                    Console.WriteLine("2. Update Surame");
                    Console.WriteLine("3. Update Age");
                    Console.WriteLine("4. None");
                    Console.Write("What would you like?(numbers of action): ");
                    string input = Console.ReadLine();
                    isInterface = false;

                    switch (input)
                    {
                        case "1":
                            Console.Write("New Name: ");
                            this._employees[index].Name = Console.ReadLine();
                            break;
                        case "2":
                            Console.Write("New Surname: ");
                            this._employees[index].Surname = Console.ReadLine();
                            break;
                        case "3":
                            Console.Write("New Age: ");
                            input = Console.ReadLine();
                            this._employees[index].Age = Convert.ToByte(input);
                            break;
                        case "4":
                            break;
                        default:
                            Console.WriteLine("Try again.");
                            isInterface = true;
                            break;
                    }
                } while (isInterface);
                this._employees[index].Username = "update";
            }
            else
            {
                Console.WriteLine(user + " Not founded.");
            }
        }
    }
}
