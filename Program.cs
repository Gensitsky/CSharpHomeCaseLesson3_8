/*
    Придумать класс, описывающий студента. Преду-
    смотреть в нем следующие моменты: фамилия, имя,
    отчество, группа, возраст, массив (зубчатый) оценок по
    программированию, администрированию и дизайну.
    А также добавить методы по работе с перечисленными
    данными: возможность установки/получения оценки,
    получение среднего балла по заданному предмету,
    распечатка данных о студенте.
*/
using System;

namespace CSharpHomeCaseLesson3_8
{
    enum Subjects
    {
        Programming,
        Administration,
        ComputerDesign
    }
    class Student
    {
        private int _studentId;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _group;
        private int _age;
        private int[][] _mark;
        private int _countP;
        private int _countA;
        private int _countD;

        public Student(int id, string fName, string mName,
            string lName, string group, int age)
        {
            _studentId = id;
            _firstName = fName;
            _middleName = mName;
            _lastName = lName;
            _group = group;
            _age = age;
            _mark = new int[3][] { new int[5],
                                   new int[5],
                                   new int[5]
                                 };
            _countP = 0;
            _countA = 0;
            _countD = 0;
        }
        public void AddMark(Subjects subject, int mark)
        {
            switch (subject)
            {
                case Subjects.Programming:
                    _mark[(int)subject].SetValue(mark, _countP);
                    _countP++;
                    Console.WriteLine($"Evaluation of {Subjects.Programming}" +
                        $": {mark}");
                    break;
                case Subjects.Administration:
                    _mark[(int)subject].SetValue(mark, _countA);
                    _countA++;
                    Console.WriteLine($"Evaluation of {Subjects.Administration}" +
                        $": {mark}");
                    break;
                case Subjects.ComputerDesign:
                    _mark[(int)subject].SetValue(mark, _countD);
                    _countD++;
                    Console.WriteLine($"Evaluation of {Subjects.ComputerDesign}" +
                        $": {mark}");
                    break;
                default:
                    break;
            }
        }
        public void AverMark(Subjects subject)
        {
            int result = 0;
            switch (subject)
            {
                case Subjects.Programming:
                    for (int i = 0; i < _countP; i++)
                    {
                        result += _mark[(int)subject][i];
                    }
                    result /= _countP;
                    break;
                case Subjects.Administration:
                    for (int i = 0; i < _countA; i++)
                    {
                        result += _mark[(int)subject][i];
                    }
                    result /= _countA;
                    break;
                case Subjects.ComputerDesign:
                    for (int i = 0; i < _countD; i++)
                    {
                        result += _mark[(int)subject][i];
                    }
                    result /= _countD;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Average mark on {subject}: {result}");
        }
        public void GetStudentMarks()
        {
            Console.WriteLine("\nMarks:");
            for (int i = 0; i < _mark.Length; i++)
            {
                Console.Write((Subjects)i + ":\t");
                foreach (var item in _mark[i])
                {
                    Console.Write(item + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void PrintStudentInfo()
        {
            Console.WriteLine($"List:\t{_studentId}");
            Console.WriteLine($"First:\t{_firstName}");
            Console.WriteLine($"Middle:\t{_middleName}");
            Console.WriteLine($"Last:\t{_lastName}");
            Console.WriteLine($"Group:\t{_group}");
            Console.WriteLine($"Age:\t{_age}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(1, "Vadim", "Iosifivich",
                "Gensitsky", "29SP1", 40);

            student1.PrintStudentInfo();
            student1.GetStudentMarks();
 
            student1.AddMark(Subjects.Programming, 9);
            student1.AddMark(Subjects.Programming, 7);
            student1.AddMark(Subjects.Administration, 6);
            student1.AddMark(Subjects.Administration, 9);
            student1.AddMark(Subjects.Administration, 7);
            student1.AddMark(Subjects.ComputerDesign, 8);
            student1.AddMark(Subjects.ComputerDesign, 6);
            student1.AddMark(Subjects.ComputerDesign, 5);
            student1.AddMark(Subjects.ComputerDesign, 4);

            student1.GetStudentMarks();

            student1.AverMark(Subjects.Programming);
            student1.AverMark(Subjects.Administration);
            student1.AverMark(Subjects.ComputerDesign);

            Console.ReadKey();
        }
    }
}
