namespace VoresLystFiskerPortal.Models
{
    public class WeatherInfo
    {
        public string Name { get; set; }  
        public WeatherMain Main { get; set; }   
        public List<WeatherDescription> Weather { get; set; }
    }

    public class WeatherMain
    {
        public double Temp { get; set; }  
    }

    public class WeatherDescription
    {
        public string Description { get; set; }    
    }
}
