# TechnogymSkillbike
Create .tcx files from MyWellness (Technogym) workouts 

Sample MyWellness workout (this can be obtained using dev tools):
```
{
  "data": {
    "analitics": {
      "descriptor": [
        {
          "i": 0,
          "pr": {
            "name": "Power",
            "um": "Watt"
          }
        },
        {
          "i": 1,
          "pr": {
            "name": "Rpm",
            "um": "Rpm"
          }
        },
        {
          "i": 2,
          "pr": {
            "name": "Speed",
            "um": "Km_h"
          }
        },
        {
          "i": 3,
          "pr": {
            "name": "Grade",
            "um": "Percent"
          }
        },
        {
          "i": 4,
          "pr": {
            "name": "HDistance",
            "um": "Meter"
          }
        },
        {
          "i": 5,
          "pr": {
            "name": "Elevation",
            "um": "Meter"
          }
        }
      ],
      "samples": [
        {
          "vs": [ 26.0, 70.0, 21.9, 0.0, 2.0, 0.05 ],
          "t": 5
        },
        {
          "vs": [ 110.0, 96.0, 25.997272403523169, 0.0, 32.0, 0.0 ],
          "t": 10
        },
        {
          "vs": [ 118.0, 103.0, 26.685663601250635, 0.0, 19465.0, 0.0 ],
          "t": 2215
        {
          "vs": [ 109.0, 74.0, 25.9087795789335, 0.0, 33815.0, 0.0 ],
          "t": 3780
        }
      ]
    },
    "equipmentType": "Skillbike",
    "cardioLogId": "6819ef1449515d79c878d08b",
    "favorite": 0,
    "name": "Eigen keuze oefening tijd - vermogen",
    "date": "6-5-2025",
    "target": "Duration",
    "nEser": 3,
    "nAttr": 1018,
    "physicalActivityId": "68802bb9-5568-475e-94c1-1c6f3248f1a1",
    "physicalActivityName": "Eigen keuze oefening tijd - vermogen",
    "data": [
      {
        "property": "Duration",
        "name": "Duur",
        "value": "63:00",
        "uM": "min",
        "rawValue": 63.0
      },
      {
        "property": "HDistance",
        "name": "Afstand",
        "value": "33,82",
        "uM": "km",
        "rawValue": 33.82
      },
      {
        "property": "Move",
        "name": "MOVEs",
        "value": "1997",
        "uM": "MOVEs",
        "rawValue": 1997.0
      },
      {
        "property": "Elevation",
        "name": "Hoogte",
        "value": "0",
        "uM": "Meters",
        "rawValue": 0.0
      }
    ]
  },
  "token": "",
  "version": "1.1.169.17825",
  "expireIn": 31104000
}
```