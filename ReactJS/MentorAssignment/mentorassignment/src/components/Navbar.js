import React from 'react';
import { Link } from 'react-router-dom';
import '../css/Navbar.css';

const Navbar = ({ isLoggedIn, onLogout }) => {
  return (
    <nav className="navbar">
      <div className="navbar-item">
        <Link to="/"><i className="fas fa-home"></i> Home</Link>
      </div>
      <div className="navbar-item">
        <Link to="/posts"><i className="fas fa-book"></i> Posts/Books</Link>
      </div>
      {isLoggedIn ? (
        <>
          <div className="navbar-item">
            <Link to="/profile"><i className="fas fa-user"></i> Profile</Link>
          </div>
          <div className="navbar-item">
            <button onClick={onLogout}><i className="fas fa-sign-out-alt"></i> Logout</button>
          </div>
        </>
      ) : (
        <>
          <div className="navbar-item">
            <Link to="/login"><i className="fas fa-sign-in-alt"></i> Login</Link>
          </div>
          <div className="navbar-item">
            <Link to="/register"><i className="fas fa-user-plus"></i> Register</Link>
          </div>
        </>
      )}
    </nav>
  );
};

export default Navbar;
