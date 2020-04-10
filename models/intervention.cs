using System;

public class Intervention
{
    public long id { get; set; }
    public string author { get; set; }
    public long customer_id { get; set; }
    public long building_id { get; set; }
    public long battery_id { get; set; }
    public long column_id { get; set; }
    public long elevator_id { get; set; }
    // public long employee_id { get; set; }
    public DateTime? start_intervention { get; set; }
    public DateTime? end_intervention { get; set; }
    public string result { get; set; }
    public string report { get; set; }
    public string status { get; set; }
}