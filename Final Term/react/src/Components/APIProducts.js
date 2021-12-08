//fake api json placeholder is used for demonstration purpose
import React, {useState,useEffect} from 'react';
import axios from 'axios';


const APIProducts = ()=>{
    const [products, setProducts] = useState([]);
    
    
    useEffect(()=>{
        axios.get("api/product/list")
        .then(resp=>{
            console.log(resp.data);
            setProducts(resp.data);
        }).catch(err=>{
            console.log(err);
        });
    },[]);

    return(
        /*<div>
            <table>
                <thead>
                    <tr><th>Id</th><th>Name</th></tr>
                </thead>
                <tbody>
                {
                    posts.map(post=>(
                        <tr key={post.id}>
                            <td>{post.id}</td>
                            <td>{post.title}</td>
                        </tr>
                    ))
                }
                </tbody>
            </table>
        </div>*/
        <div>
            <h1>Products</h1>
             <ul>
                {
                
                    products.map(p=>(
                    <li  key={p.id}> {p.name}</li>
                    )) 
                }
             </ul>
        </div>
    )

}

export default APIProducts;