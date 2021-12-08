import React from 'react'

const Product=(props)=>{
    
    return(
        <div>
            Name: {props.name}<br/>
            Price: {props.price}
        </div>
    )
}

export default Product;