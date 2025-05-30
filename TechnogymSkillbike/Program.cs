using System.Globalization;
using System.Text.Json;

Console.WriteLine("Creating tcx file.");

// Change this name
var filename = "2025-05-06_workout";

var filePath = "Data/" + filename + ".json";
using FileStream stream = File.OpenRead(filePath);
var workout = JsonSerializer.Deserialize<Workout>(stream) ?? throw new Exception("No workout");

var powerIndex = 0;
var rpmIndex = 1;
var speedIndex = 2;
var distanceIndex = 4;
var elevationIndex = 5;

var dateFormat = "yyyy-MM-ddTHH:mm:ssZ";

var date = DateTime.ParseExact(workout.data.date, "d-M-yyyy", CultureInfo.InvariantCulture).ToUniversalTime().AddHours(8);
var totalTimeSeconds = workout.data.data.First(dataItem => dataItem.property == "Duration").rawValue * 60;
var distanceMeters = workout.data.data.First(dataItem => dataItem.property == "HDistance").rawValue * 1000;
var maximumSpeed = workout.data.analitics.samples.Select(sample => sample.vs[speedIndex]).Max();
var averageCadence = (int)workout.data.analitics.samples.Select(sample => sample.vs[rpmIndex]).Average();

var tcx = "";
// Add Preamble
tcx = $"{tcx}<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<TrainingCenterDatabase xsi:schemaLocation=\"http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2 http://www.garmin.com/xmlschemas/TrainingCenterDatabasev2.xsd\" xmlns:ns5=\"http://www.garmin.com/xmlschemas/ActivityGoals/v1\" xmlns:ns3=\"http://www.garmin.com/xmlschemas/ActivityExtension/v2\" xmlns:ns2=\"http://www.garmin.com/xmlschemas/UserProfile/v2\" xmlns=\"http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n <Activities>\r\n  <Activity Sport=\"Biking\">";
tcx = $"{tcx}\r\n   <Id>{date.ToString(dateFormat)}</Id>";
tcx = $"{tcx}\r\n   <Lap StartTime=\"{date.ToString(dateFormat)}\">";
tcx = $"{tcx}\r\n    <TotalTimeSeconds>{totalTimeSeconds}</TotalTimeSeconds>";
tcx = $"{tcx}\r\n    <DistanceMeters>{distanceMeters}</DistanceMeters>";
tcx = $"{tcx}\r\n    <MaximumSpeed>{maximumSpeed.ToString(new CultureInfo("en-US"))}</MaximumSpeed>";
tcx = $"{tcx}\r\n    <Cadence>{averageCadence}</Cadence>";
tcx = $"{tcx}\r\n    <TriggerMethod>Manual</TriggerMethod>";
tcx = $"{tcx}\r\n    <Track>";

// Add Trackpoints
workout.data.analitics.samples.ForEach(sample => {
    var time = date.AddSeconds(sample.t);
    var elevation = sample.vs[elevationIndex];
    var distance = sample.vs[distanceIndex];
    var cadence = (int)sample.vs[rpmIndex];
    var speed = sample.vs[speedIndex];
    var power = (int)sample.vs[powerIndex];
    

    tcx = $"{tcx}\r\n     <Trackpoint>";
    tcx = $"{tcx}\r\n      <Time>{time.ToString(dateFormat)}</Time>";
    tcx = $"{tcx}\r\n      <Position>\r\n       <LatitudeDegrees>51.9214787</LatitudeDegrees>\r\n       <LongitudeDegrees>4.4028409</LongitudeDegrees>\r\n      </Position>";
    tcx = $"{tcx}\r\n      <AltitudeMeters>{elevation.ToString(new CultureInfo("en-US"))}</AltitudeMeters>";
    tcx = $"{tcx}\r\n      <DistanceMeters>{distance.ToString(new CultureInfo("en-US"))}</DistanceMeters>";
    tcx = $"{tcx}\r\n      <Cadence>{cadence}</Cadence>";
    tcx = $"{tcx}\r\n      <Extensions>\r\n       <TPX xmlns=\"http://www.garmin.com/xmlschemas/ActivityExtension/v2\">";
    tcx = $"{tcx}\r\n        <Speed>{speed.ToString("N1", new CultureInfo("en-US"))}</Speed>";
    tcx = $"{tcx}\r\n        <Watts>{power}</Watts>";
    tcx = $"{tcx}\r\n       </TPX>\r\n      </Extensions>";
    tcx = $"{tcx}\r\n     </Trackpoint>";
});

// Add Postamble
tcx = $"{tcx}\r\n    </Track>\r\n   </Lap>\r\n  </Activity>\r\n </Activities>\r\n</TrainingCenterDatabase>";

// Write file
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"{filename}.tcx")))
{
    outputFile.WriteLine(tcx);
}