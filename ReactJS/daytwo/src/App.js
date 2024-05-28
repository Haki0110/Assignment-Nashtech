import React, { useState } from 'react';
import './App.css';
import Welcome from './components/Welcome';
import Counter from './components/Counter';
import Pokemon from './components/Pokemon';
import RegisterForm from './components/RegisterForm';

function App() {
  const [valueSelected, setValueSelected] = useState("1");

  const profileData = [
    {
      name: "Sara",
      age: "20",
      backgroundColor: 'yellow'
    },
    {
      name: "Haki",
      age: "22",
      backgroundColor: 'red'
    },
    {
      name: "Sara",
      age: "21",
      backgroundColor: 'blue'
    }
  ];

  const handleOnChange = (event) => {
    setValueSelected(event.target.value);
  };

  const renderComponent = () => {
    switch (valueSelected) {
      case "1":
        return (
          <div>
            {profileData.map((profile, index) => (
              <Welcome key={index} profile={profile} />
            ))}
          </div>
        );
      case "2":
        return (
          <div className="counterJS">
            <Counter />
          </div>
        );
      case "3":
        return (
          <div className="pokemon-container">
            <Pokemon />
          </div>
        );
      case "4":
        return (
          <div className="register-form">
            <RegisterForm />
          </div>
        );
      default:
        return null;
    }
  };

  return (
    <div className="App">
      <select name="selectOption" className="select-cs" onChange={handleOnChange} value={valueSelected}>
        <option value="1">Welcome</option>
        <option value="2">Counter</option>
        <option value="3">Pokemon</option>
        <option value="4">Register</option>
      </select>
      <div>
        {renderComponent()}
      </div>
    </div>
  );
}

export default App;
