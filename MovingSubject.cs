using System;
namespace MovingSubject
{
    delegate void navigate();
    interface IPrintable
	{
		void printable();
	}
	interface IMovable
	{
		void moveup();
		void movedown();
		void moveleft();
		void moveright();
	}
	class Position
	{
		public int x { get; set; }
		public int y { get; set; }
        public static int id = 0;
        public int number { get; set; }
        
        public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
            number = id;
			id++;
		}

    }
    class Jet : Position, IPrintable, IMovable
    {
        public string maker { get; set; }
        public int product { get; set; }
        public int max { get; set; }
        public string type = "Jet";
     
        public Jet(int x, int y, string maker, int product, int max) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.maker = maker;
            this.product = product;
            this.max = max;
            
            number = id;


        }
        public void movedown()
        {
            y -= 100;
        }

        public void moveleft()
        {
            x -= 100;
        }

        public void moveright()
        {
            x += 100;
        }

        public void moveup()
        {
            y += 100;
        }

        public new void printable()
        {
            Console.WriteLine("ID : {0} 종류 : {1} 메이커 : {2} 생산년도 : {3} 최대속도 : {4} 좌표 {5}, {6}|", number, type, maker, product, max, x, y);
        }
        

        

    }
    class F15 : Jet, IPrintable, IMovable//navigeate는 델리게이트를 받아 x,y를 넣음
    {
        public string maker { get; set; }
        public int product { get; set; }
        public int max { get; set; }
        public new string type = "F15";
        public F15(int x, int y, string maker, int product, int max) : base(x, y, maker, product, max)
        {
            this.x = x;
            this.y = y;
            this.maker = maker;
            this.product = product;
            this.max = max;

            number = id;
        }
        public new void movedown()
        {
            y -= 500;
        }

        public new void moveleft()
        {
            x -= 500;
        }

        public new void moveright()
        {
            x += 500;
        }

        public new void moveup()
        {
            y += 500;
        }

        public new void printable()
        {
            Console.WriteLine("ID : {0} 종류 : {1} 메이커 : {2} 생산년도 : {3} 최대속도 : {4} 좌표 {5}, {6}|", number, type, maker, product, max, x, y);
        }
    }
    
	class Program
	{
		static void Main(String[] args)
		{
            string maker;
            int product;
            int max;
            int x;
            int y;
            List<Position> positions = new List<Position>();
            Jet test1 = new Jet(0, 0, "us", 2022, 500);
            F15 test2 = new F15(0, 0, "kor", 2023, 800);
            positions.Add((Jet)test1);
            positions.Add((F15)test2);
            while (true)
            {
                Console.WriteLine("1. 제트기 추가  2. F15추가  3. 현황 출력  4. 이동  5. x-좌표 정렬  6. 콜백 방향 조언  7. 종료");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("메이커:");
                    maker = Console.ReadLine();
                    Console.WriteLine("생산년도: ");
                    product = int.Parse(Console.ReadLine());
                    Console.WriteLine("최대 속도: ");
                    max = int.Parse(Console.ReadLine());
                    Console.WriteLine("x값: ");
                    x = int.Parse(Console.ReadLine());
                    Console.WriteLine("y값: ");
                    y = int.Parse(Console.ReadLine());
                    Jet jet = new Jet(x, y, maker, product, max);
                    positions.Add((Jet)jet);

                }
                else if (input == 2)
                {
                    Console.WriteLine("메이커:");
                    maker = Console.ReadLine();
                    Console.WriteLine("생산년도: ");
                    product = int.Parse(Console.ReadLine());
                    Console.WriteLine("최대 속도: ");
                    max = int.Parse(Console.ReadLine());
                    Console.WriteLine("x값: ");
                    x = int.Parse(Console.ReadLine());
                    Console.WriteLine("y값: ");
                    y = int.Parse(Console.ReadLine());
                    F15 f15 = new F15(x, y, maker, product, max);
                    positions.Add((F15)f15);
                }
                else if (input == 3)
                {
                    foreach (var item in positions)
                    {
                        if (item is Jet)
                        {

                            ((Jet)item).printable();
                        }
                        if (item is F15)
                        {
                            ((F15)item).printable();
                        }

                    }
                }
                else if (input == 4)
                {

                    Console.WriteLine("이동할 ID : ");
                    int ID = int.Parse(Console.ReadLine());
                    foreach (var item in positions)
                    {
                        if(item.number == ID)
                        {
                            if(item is Jet)
                            {
                                Console.WriteLine("1. UP  2. DOWN  3. LEFT  4. RIGHT ");
                                int MOVE = int.Parse(Console.ReadLine());
                                if (MOVE == 1)
                                {
                                    ((Jet)item).moveup();
                                }
                                else if (MOVE == 2)
                                {
                                    ((Jet)item).movedown();
                                }
                                else if (MOVE == 3)
                                {
                                    ((Jet)item).moveleft();
                                }
                                else if (MOVE == 4)
                                {
                                    ((Jet)item).moveright();
                                }
                            }
                            else if(item is F15)
                            {
                                Console.WriteLine("1. UP  2. DOWN  3. LEFT  4. RIGHT ");
                                int MOVE = int.Parse(Console.ReadLine());
                                if (MOVE == 1)
                                {
                                    ((F15)item).moveup();
                                }
                                else if (MOVE == 2)
                                {
                                    ((F15)item).movedown();
                                }
                                else if (MOVE == 3)
                                {
                                    ((F15)item).moveleft();
                                }
                                else if (MOVE == 4)
                                {
                                    ((F15)item).moveright();
                                }
                            }
                            
                        }

                    }

                    



                }
                else if (input == 5)
                {
                    
                    positions.Sort((a, b) => a.x.CompareTo(b.x));
                    Console.WriteLine("x-좌표로 정렬된 결과:");
                    foreach (var item in positions)
                    {
                        if (item is Jet)
                        {
                            ((Jet)item).printable();
                        }
                        else if (item is F15)
                        {
                            ((F15)item).printable();
                        }
                    }

                }
                else if (input == 6)
                {
                    Console.WriteLine("현재 위치를 기준으로 가장 가까운 비행기로 이동 방향을 제안합니다.");
                    Console.WriteLine("현재 비행기의 ID를 입력하세요: ");
                    int currentID = int.Parse(Console.ReadLine());
                    Position currentPosition = positions.FirstOrDefault(p => p.number == currentID);

                    if (currentPosition != null)
                    {
                        double minDistance = double.MaxValue;
                        Position closest = null;

                        foreach (var item in positions)
                        {
                            if (item.number != currentID)
                            {
                                double distance = Math.Sqrt(Math.Pow(item.x - currentPosition.x, 2) + Math.Pow(item.y - currentPosition.y, 2));
                                if (distance < minDistance)
                                {
                                    minDistance = distance;
                                    closest = item;
                                }
                            }
                        }

                        if (closest != null)
                        {
                            Console.WriteLine($"가장 가까운 비행기는 ID: {closest.number}입니다. 이동 방향은 다음과 같습니다:");
                            if (closest.x > currentPosition.x)
                                Console.WriteLine("오른쪽으로 이동하세요.");
                            else if (closest.x < currentPosition.x)
                                Console.WriteLine("왼쪽으로 이동하세요.");

                            if (closest.y > currentPosition.y)
                                Console.WriteLine("위쪽으로 이동하세요.");
                            else if (closest.y < currentPosition.y)
                                Console.WriteLine("아래쪽으로 이동하세요.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("유효하지 않은 ID입니다.");
                    }
                }
                else if (input == 7)
                {
                    break;
                }
            }
            

        }
	}
	
}

