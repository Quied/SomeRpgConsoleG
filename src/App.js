import React from 'react';
import './App.css';

const Cities = [
  {
    "city": "Kyiv",
    "latitude": 50.4501,
    "longitude": 30.5234
  },
  {
    "city": "Kharkiv",
    "latitude": 49.9935,
    "longitude": 36.2304
  },
  {
    "city": "Dnipro",
    "latitude": 48.4647,
    "longitude": 35.0462
  },
  {
    "city": "Odessa",
    "latitude": 46.4825,
    "longitude": 30.7233
  },
  {
    "city": "Lviv",
    "latitude": 49.8397,
    "longitude": 24.0297
  },
  {
    "city": "Zaporizhzhia",
    "latitude": 47.8388,
    "longitude": 35.1396
  },
  {
    "city": "Kryvyi Rih",
    "latitude": 47.9100,
    "longitude": 33.3919
  },
  {
    "city": "Mykolaiv",
    "latitude": 46.9750,
    "longitude": 31.9946
  },
  {
    "city": "Mariupol",
    "latitude": 47.0958,
    "longitude": 37.5411
  },
  {
    "city": "Luhansk",
    "latitude": 48.574,
    "longitude": 39.307
  }
]

const Students = [
  "Student 1",
  "Student 2",
  "Student 3",
  "Student 4",
  "Student 5",
  "Student 6",
  "Student 7",
  "Student 8",
  "Student 9",
  "Student 10",
]

class User {
  constructor(str, obj) {
    this.stringParam = str;
    this.objectParam = obj;
  }

  displayParams() {
    console.log("String parameter:", this.stringParam);
    console.log("Object parameter:", this.objectParam);
  }
}

function degreesToRadians(degrees) {
  return degrees * Math.PI / 180;
}

function distance(lat1, lon1, lat2, lon2) {
  const R = 6371; // Earth's radius in km
  const dLat = degreesToRadians(lat2 - lat1);
  const dLon = degreesToRadians(lon2 - lon1);
  const a =
    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
    Math.cos(degreesToRadians(lat1)) * Math.cos(degreesToRadians(lat2)) *
    Math.sin(dLon / 2) * Math.sin(dLon / 2);
  const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
  const distance = R * c;
  return distance; // Distance in km
}

const StudentsList = () => {
  const assignRandomCity = () => {
    const randomCityIndex = Math.floor(Math.random() * Cities.length);
    return Cities[randomCityIndex].city;
  };

  return (
    <div>
      {Students.map((student, index) => (
        <div key={index}>
          <h5>{`${student} - ${assignRandomCity()}`}</h5>
        </div>
      ))}
    </div>
  )
}

const showDistanceBetween = () => {
  const randomStudentIndex1 = Math.floor(Math.random() * Students.length);
  const randomStudentIndex2 = Math.floor(Math.random() * Students.length);
  const student1 = Students[randomStudentIndex1];
  const student2 = Students[randomStudentIndex2];
  const city1 = Cities[randomStudentIndex1];
  const city2 = Cities[randomStudentIndex2];
  const distanceBetween = distance(city1.latitude, city1.longitude, city2.latitude, city2.longitude);

  return (
    <div>
      <h3>{`Random student: ${student1} ${city1.city}`}</h3>
      <h3>{`Random student: ${student2} ${city2.city}`}</h3>
      <h5>{`Distance between students: ${distanceBetween.toFixed(2)} km`}</h5>
    </div>
  );
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
       <div className="Wrapper">
          <div>
            <StudentsList />
          </div>
          <div>
            {showDistanceBetween()}
          </div>
       </div>
      </header>
    </div>
  );
}

export default App;
