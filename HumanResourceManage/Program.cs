using System;
using System.Collections.Generic;

namespace HumanResourceManage
{
    class Human
    {
        public static int count = 0;
        public readonly int id = 0;
        public string name;    //이름
        public string gender;   //성
        public string phonenumber;  //전화번호
        private string id_code;//주민번호
        public string Id_code
        {
            get
            {
                return id_code;
            }
            set
            {
                id_code = value;
            }
        }

        public string Revise_code
        {
            get { return id_code; }
            set
            {
                for (; ; )
                {
                    int A = (value[2] - '0') * 10;
                    int B = value[3] - '0';
                    int month = A + B;
                    int C = (value[4] - '0') * 10;
                    int D = value[5] - '0';
                    int day = C + D;

                    if (month > 0 && month < 13 && day > 0 && day < 32)
                    {
                        id_code = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("정확하지 않은 주민번호");
                        Console.Write("수정하기 : ");
                        value = Console.ReadLine();
                        continue;
                    }
                }
            }
        }

        public string adress;   //주소
        public string job;      //직업 

        public Human(string num)
        {
            if (num == "1") count++;
            else if (num == "3") count--;
            id = count;
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //각 항목별 리스트 만들기 
            List<Human> list = new List<Human>();
            list.Add(new Human("1") { name = "윤인성", gender = "남", adress = "구지동", job = "공무원", phonenumber = "01000000000", Id_code = "121130" });
            list.Add(new Human("1") { name = "이도훈", gender = "여", adress = "송강동", job = "의사", phonenumber = "010111111111", Id_code = "870413" });
            list.Add(new Human("1") { name = "가나다", gender = "남", adress = "쌍문동", job = "판사", phonenumber = "01022222222", Id_code = "760412" });
            list.Add(new Human("1") { name = "마바사", gender = "여", adress = "오롱동", job = " \t", phonenumber = " \t", Id_code = "980313" });
            list.Add(new Human("1") { name = "아자차", gender = "남", adress = "둔산동", job = "장의사", phonenumber = "01044444444", Id_code = "980113" });
            list.Add(new Human("1") { name = "타카파", gender = "여", adress = "관평동", job = "\t ", phonenumber = "01055555555", Id_code = "200313" });
            list.Add(new Human("1") { name = "일이삼", gender = "남", adress = "대신동", job = "치위생사", phonenumber = "01066666666", Id_code = "770513" });
            list.Add(new Human("1") { name = "사오육", gender = "여", adress = "고충동", job = "위생사", phonenumber = "01077777777", Id_code = "660513" });
            list.Add(new Human("1") { name = "칠팔구", gender = "남", adress = "관저동", job = "영양사", phonenumber = "01088888888", Id_code = "440313" });
            list.Add(new Human("1") { name = "십십일", gender = "여", adress = "가리봉동", job = "공무원", phonenumber = "\t ", Id_code = "220313" });

            //1,2,3,4,5,6 번호 반복 실시 
            for (; ; )
            {
                Console.WriteLine("1. 회원가입, 2. 회원전체출력, 3. 회원삭제, 4. 회원정보변경, 5. 회원정보검색, 6. 종료");
                Console.Write("입력: ");
                String num = Console.ReadLine();

                if (num == "1") //1.회원가입
                {

                    Console.WriteLine("이름 : 성별 : 주소 : 직업 : 전화번호 : 주민번호");
                    list.Add(new Human("1") { name = Console.ReadLine(), gender = Console.ReadLine(), adress = Console.ReadLine(), job = Console.ReadLine(), phonenumber = Console.ReadLine(), Revise_code = Console.ReadLine() });

                    Console.WriteLine("회원 전체 출력");
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.name + " " + item.gender + " " + item.adress + " " + item.job + " " + item.phonenumber + " " + item.Id_code);
                    }
                    Console.WriteLine("count : " + Human.count);
                }
                else if (num == "2") //2.회원 전체 출력
                {
                    Console.WriteLine("회원 전체 출력");
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.name + " " + item.gender + " " + item.adress + " " + item.job + " " + item.phonenumber + " " + item.Id_code);
                    }
                    Console.WriteLine("count : " + Human.count);
                }
                else if (num == "3") //3. 회원 삭제
                {
                    Console.WriteLine("삭제할 회원 전화번호 또는 주민번호 : ");
                    Console.Write("삭제할 회원 정보 : ");
                    string gram = Console.ReadLine();

                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (list[i].phonenumber == gram)
                        {
                            list.RemoveAt(i);
                            new Human("3");
                        }

                        if (list[i].Id_code == gram)
                        {
                            list.RemoveAt(i);
                            new Human("3");
                        }
                    }
                    Console.WriteLine("회원 전체 출력");
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.name + " " + item.gender + " " + item.adress + " " + item.job + " " + item.phonenumber + " " + item.Id_code);
                    }
                    Console.WriteLine(Human.count);

                }
                else if (num == "4") //4. 회원정보변경 전화 번호,주민번호
                {                    //
                    Console.WriteLine("전화번호 혹은 주민번호");
                    Console.Write("변경할 회원 정보 : ");
                    string gram = Console.ReadLine();
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        //전화번호
                        if (list[i].phonenumber == gram)
                        {
                            Console.Write("이전 정보 : ");
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].adress + " " + list[i].job + " " + list[i].phonenumber + " " + list[i].Id_code);
                            Console.WriteLine("수정하기 ");
                            Console.Write("이름 :");
                            list[i].name = Console.ReadLine();
                            Console.Write("성별 :");
                            list[i].gender = Console.ReadLine();
                            Console.Write("주소 :");
                            list[i].adress = Console.ReadLine();
                            Console.Write("직업 :");
                            list[i].job = Console.ReadLine();
                            Console.Write("전화번호 :");
                            list[i].phonenumber = Console.ReadLine();
                            Console.Write("주민번호 :");
                            list[i].Revise_code = Console.ReadLine();
                        }
                        //주민번호 
                        if (list[i].Id_code == gram)
                        {
                            Console.Write("이전 정보 : ");
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].adress + " " + list[i].job + " " + list[i].phonenumber + " " + list[i].Id_code);
                            Console.WriteLine("수정하기 ");
                            Console.Write("이름 :");
                            list[i].name = Console.ReadLine();
                            Console.Write("성별 :");
                            list[i].gender = Console.ReadLine();
                            Console.Write("주소 :");
                            list[i].adress = Console.ReadLine();
                            Console.Write("직업 :");
                            list[i].job = Console.ReadLine();
                            Console.Write("전화번호 :");
                            list[i].phonenumber = Console.ReadLine();
                            Console.Write("주민번호 :");
                            list[i].Revise_code = Console.ReadLine();

                        }
                    }
                }
                else if (num == "5") //회원 정보 검색
                {
                    //이름: 성별: 주민번호: 주소: 번화번호: 직업
                    Console.WriteLine("회원 정보 검색");
                    Console.Write("이름 : ");
                    string one = Console.ReadLine();
                    Console.Write("성별 : ");
                    string two = Console.ReadLine();
                    Console.Write("주민번호 : ");
                    string three = Console.ReadLine();
                    Console.Write("주소 : ");
                    string four = Console.ReadLine();
                    Console.Write("전화번호 : ");
                    string five = Console.ReadLine();
                    Console.Write("직업 : ");
                    string six = Console.ReadLine();

                    for (int i = list.Count - 1; i >= 0; i--)
                    {

                        if (list[i].name == one)
                        {
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].Id_code + " " + list[i].adress + " " + list[i].phonenumber + " " + list[i].job);
                            continue;
                        }

                        if (list[i].gender == two)
                        {
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].Id_code + " " + list[i].adress + " " + list[i].phonenumber + " " + list[i].job);
                            continue;
                        }
                        if (list[i].Id_code == three)
                        {
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].Id_code + " " + list[i].adress + " " + list[i].phonenumber + " " + list[i].job);
                            continue;
                        }

                        if (list[i].adress == four)
                        {
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].Id_code + " " + list[i].adress + " " + list[i].phonenumber + " " + list[i].job);
                            continue;
                        }
                        if (list[i].phonenumber == five)
                        {
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].Id_code + " " + list[i].adress + " " + list[i].phonenumber + " " + list[i].job);
                            continue;
                        }

                        if (list[i].job == six)
                        {
                            Console.WriteLine(list[i].name + " " + list[i].gender + " " + list[i].Id_code + " " + list[i].adress + " " + list[i].phonenumber + " " + list[i].job);
                            continue;
                        }


                    }
                }
                else if (num == "6") //6.종료
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("잘못된 번호입니다.");
                }


            }


        }


    }


}