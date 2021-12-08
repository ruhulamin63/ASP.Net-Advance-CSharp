import React,{useState} from 'react';

const ColorChange=()=>{
    var [color,setColor] = useState("Red");

   

    return(
        <div>
            <h1 style={{backgroundColor:color}}>Now the chosen color is {color}</h1>
            <button onClick={()=>setColor("Black")}>Black</button>
            <button onClick={()=>setColor("Green")}>Green</button>
            <button onClick={()=>setColor("Yellow")}>Yellow</button>
            <button onClick={()=>setColor("Blue")}>Blue</button>
        </div>
    )

}

export default ColorChange;