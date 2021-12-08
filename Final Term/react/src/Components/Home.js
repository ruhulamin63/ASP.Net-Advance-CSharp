import React from 'react';
import Click from './Click';
import Hello from './Hello';
const Home =()=>{
    return (
        <div>
            <Hello/>
            <Click count="1"/>
        </div>
    )
}
export default Home;