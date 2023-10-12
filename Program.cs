using System;
using System.Collections.Generic;
class Grandma
{
   public string Name { get; set; }
   public int Age { get; set; }
   public List<string> Illnesses { get; set; }
   public List<string> Medicines { get; set; }
   public Grandma(string name, int age, List<string> illnesses, List<string> medicines)
    {
     Name = name;
     Age = age;
     Illnesses = illnesses;
     Medicines = medicines;
     }
 }
        class Hospital
        {
            public string Name { get; set; }
            public List<string> TreatableIllnesses { get; set; }
            public int Capacity { get; set; }
            public int Occupancy { get; set; }

            public Hospital(string name, List<string> treatableIllnesses, int capacity)
            {
                Name = name;
                TreatableIllnesses = treatableIllnesses;
                Capacity = capacity;
                Occupancy = 0;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                List<Grandma> grandmas = new List<Grandma>();
                grandmas.Add(new Grandma("grandma 1", 70, new List<string> { "кашель", "лихорадка" }, new List<string> { "сироп от кашля", "парацетомол" }));
                grandmas.Add(new Grandma("grandma 2", 75, new List<string> { "головная боль", "зубная боль" }, new List<string> { "аспирин", "пепто-бисмол" }));
                grandmas.Add(new Grandma("grandma 3", 80, new List<string> { }, new List<string> { }));

                Stack<Hospital> hospitals = new Stack<Hospital>();
                hospitals.Push(new Hospital("hospital 1", new List<string> { "кашель", "лихорадка" }, 2));
                hospitals.Push(new Hospital("hospital 2", new List<string> { "головная боль", "зубная боль" }, 2));

                foreach (Grandma grandma in grandmas)
                {
                    if (grandma.Illnesses.Count == 0)
                    {
                        Hospital firstAvailableHospital = hospitals.Peek();

                        if (firstAvailableHospital != null)
                        {
                            firstAvailableHospital.Occupancy++;
                            Console.WriteLine(grandma.Name + " is admitted to " + firstAvailableHospital.Name);
                        }
                    }
                    else
                    {
                        bool admittedToHospital = false;

                        foreach (Hospital hospital in hospitals)
                        {
                            int compatibleIllnessesCount = 0;

                            foreach (string illness in grandma.Illnesses)
                            {
                                if (hospital.TreatableIllnesses.Contains(illness))
                                {
                                    compatibleIllnessesCount++;
                                }
                            }

                            if ((double)compatibleIllnessesCount / grandma.Illnesses.Count > 0.5 && hospital.Occupancy < hospital.Capacity)
                            {
                                hospital.Occupancy++;
                                Console.WriteLine(grandma.Name + " is admitted to " + hospital.Name);
                                admittedToHospital = true;
                                break;
                            }
                        }
                        if (!admittedToHospital)
                        {
                            Console.WriteLine(grandma.Name + "остаётся на улице и плачет");
                        }
                    }
                }
                Console.WriteLine("List of Grandmas:");
                foreach (Grandma grandma in grandmas)
                {
                    Console.WriteLine("имя: " + grandma.Name + ", возраст: " + grandma.Age + ", болезнь: " + string.Join(", ", grandma.Illnesses) + ", медикаменты: " + string.Join(", ", grandma.Medicines));
                }
                Console.WriteLine("List of Hospitals:");
                foreach (Hospital hospital in hospitals)
                {
                    Console.WriteLine("имя: " + hospital.Name + ", излечимые болезни: " + string.Join(", ", hospital.TreatableIllnesses) + ", вместимость: " + hospital.Capacity + ", заполненность: " + hospital.Occupancy + ", процент заполненности: " + (double)hospital.Occupancy / hospital.Capacity * 100 + " %");
                }
        Console.ReadKey();
            }
        }