namespace Ticket_Web_App.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppColumnsAttribute : Attribute
    {
        public string[] Columns { get; private set; }

        public AppColumnsAttribute(params string[] columns) 
        { 
            Columns = columns;
        }
    }
}
