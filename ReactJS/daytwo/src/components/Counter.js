import React from "react";
import { useState } from "react";

function Counter() {
    const [count, setCount] = useState(0)

    const handleIncrease = () => {
        setCount(count + 1)
    }

    const handleDecrease = () => {
        setCount(count - 1)
    }

    return (
        <div style={{ display: 'flex', alignItems: 'center' }}>
            <button onClick={handleDecrease} className="count-button" >-</button>
            <h1>{count}</h1>
            <button onClick={handleIncrease} className="count-button" >+</button>
        </div>
    )

}
export default Counter;