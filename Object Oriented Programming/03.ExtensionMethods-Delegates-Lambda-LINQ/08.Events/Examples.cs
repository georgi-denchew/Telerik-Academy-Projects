using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Events
{
    //TASK 09: *Read in MSDN about the keyword event in C# and how to
    //publish events. Re-implement the above using .NET events
    //and following the best practices
    
    public delegate void EventHandler(object sender, EventArgs e);

    public class CustomEventArgs : EventArgs
    {
        private string message;

        public CustomEventArgs(string str)
        {
            this.message = str;
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
    }

    class Publisher
    {
        public event EventHandler<CustomEventArgs> RaiseEvent;

        public void Raise()
        {
            Console.WriteLine("This month's main event will be on March 18th.");
            OnRaiseEvent(new CustomEventArgs("Raising the event"));
        }

        protected virtual void OnRaiseEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = RaiseEvent;

            if (handler != null)
            {
                e.Message += string.Format(" at {0}", DateTime.Now.ToString());
                handler(this, e);
            }
        }
    }

    class Subscriber
    {
        private string id;
        
        public Subscriber(string id, Publisher pub)
        {
            this.id = id;
            pub.RaiseEvent += HandleEvent;
            
        }

        void HandleEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine("{0} received this message: {1}", id, e.Message);
        }
    }


    class Examples
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber subscriber1 = new Subscriber("subscriber1", pub);
            Subscriber subscriber2 = new Subscriber("subscriber2", pub);

            pub.Raise();

        }
    }
}
