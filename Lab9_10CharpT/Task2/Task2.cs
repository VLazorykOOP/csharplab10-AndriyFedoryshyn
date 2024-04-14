using System;
using System.Collections;

public class Task2
{
    public delegate void FacultyEventHandler(object sender, FacultyEventArgs e);

    public class Faculty
    {
        string facultyName;
        int departments; 
        int days; 
        Security securityTeam;
        MedicalStaff medicalStaff;
        EventCoordinator eventCoordinator;
        public event FacultyEventHandler FacultyEvent;
        private Random rnd = new Random();
        double eventProbability = 0.05; 

        public Faculty(string name, int departments, int days)
        {
            facultyName = name;
            this.departments = departments;
            this.days = days;
            securityTeam = new Security(this);
            medicalStaff = new MedicalStaff(this);
            eventCoordinator = new EventCoordinator(this);
            securityTeam.On();
            medicalStaff.On();
            eventCoordinator.On();
        }

        protected virtual void OnFacultyEvent(FacultyEventArgs e)
        {
            Console.WriteLine($"\nAt {facultyName}, event occurred in Department {e.Department} on Day {e.Day}.");
            if (FacultyEvent != null)
            {
                foreach (FacultyEventHandler handler in FacultyEvent.GetInvocationList())
                {
                    handler(this, e);
                }
            }
        }

        public void SimulateFacultyLife()
        {
            for (int day = 1; day <= days; day++)
            {
                for (int dept = 1; dept <= departments; dept++)
                {
                    if (rnd.NextDouble() < eventProbability)
                    {
                        FacultyEventArgs e = new FacultyEventArgs(dept, day);
                        OnFacultyEvent(e);
                    }
                }
            }
        }
    }

    public abstract class Receiver
    {
        protected Faculty faculty;
        public Receiver(Faculty faculty)
        {
            this.faculty = faculty;
        }
        public void On()
        {
            faculty.FacultyEvent += HandleEvent;
        }
        public void Off()
        {
            faculty.FacultyEvent -= HandleEvent;
        }
        public abstract void HandleEvent(object sender, FacultyEventArgs e);
    }

    public class Security : Receiver
    {
        public Security(Faculty faculty) : base(faculty) { }
        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            Console.WriteLine($"Security responded to an event in Department {e.Department} on Day {e.Day}.");
        }
    }

    public class MedicalStaff : Receiver
    {
        public MedicalStaff(Faculty faculty) : base(faculty) { }
        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            Console.WriteLine($"Medical staff responded to a health issue in Department {e.Department} on Day {e.Day}.");
        }
    }

    public class EventCoordinator : Receiver
    {
        public EventCoordinator(Faculty faculty) : base(faculty) { }
        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            Console.WriteLine($"Event Coordinator managed an event in Department {e.Department} on Day {e.Day}.");
        }
    }

    public class FacultyEventArgs : EventArgs
    {
        int department;
        int day;
        public int Department { get { return department; } }
        public int Day { get { return day; } }

        public FacultyEventArgs(int department, int day)
        {
            this.department = department;
            this.day = day;
        }
    }


    public static void Program2()
    {
        Console.WriteLine("Simulating Faculty Life...");
        Faculty faculty = new Faculty("Engineering Faculty", 5, 3);
        faculty.SimulateFacultyLife();
    }

}
