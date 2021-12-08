import React from 'react'
import Product from './Product';

const Hello=()=>{
    return(
        <div>
            
            <h1>This is my App</h1>
            <Product name="Huawei" price="120k"/>
            <Product name="Samsung" price="100k"/>
            <Product name="Redmi" price="80k"/>
            
        </div>
    )
}

export default Hello;
