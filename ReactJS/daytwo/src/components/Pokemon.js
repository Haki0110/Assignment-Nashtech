import React, { useState, useEffect } from 'react';

const Pokemon = () => {
  const [pokemonId, setPokemonId] = useState(1);
  const [pokemonData, setPokemonData] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchPokemonData = async () => {
      setLoading(true);
      setError(null);

      try {
        const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonId}`);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setPokemonData(data);
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchPokemonData();
  }, [pokemonId]);

  const handlePrevious = () => {
    setPokemonId((prevId) => Math.max(prevId - 1, 1));
  };

  const handleNext = () => {
    setPokemonId((prevId) => prevId + 1);
  };

  return (
    <div className="pokemon">
      <h1>Pokemon Detail</h1>
      {loading && <p>Loading...</p>}
      {error && <p>Error: {error}</p>}
      {pokemonData && (
        <div>
          <h2>{pokemonData.name}</h2>
          <img src={pokemonData.sprites.front_default} alt={pokemonData.name} />    
          <p>Id: {pokemonId}</p>      
          <p>Height: {pokemonData.height}</p>
          <p>Weight: {pokemonData.weight}</p>
        </div>
      )}
      <button onClick={handlePrevious} disabled={pokemonId === 1}>
        Previous
      </button>
      <button onClick={handleNext}>Next</button>
    </div>
  );
};

export default Pokemon;
