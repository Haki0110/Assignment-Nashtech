import React from 'react';

const Welcome = ({ profile }) => {
  return (
    <div style={{ backgroundColor: profile.backgroundColor }}>
      <p className="first-line" >
        Name: {profile.name}
      </p>
      <p className="second-line">
        Age: {profile.age}
      </p>
    </div>
  );
};

export default Welcome;
