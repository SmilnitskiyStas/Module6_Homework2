import { useEffect, useState } from 'react';
import './App.css';

function App() {
  // UseState для нашої форми.
  // const [id, setId] = useState(0);
  const [title, setTitle] = useState('');
  const [author, setAuthor] = useState('');
  const [yearOfCreate, setYearOfCreate] = useState('');
  const [price, setPrice] = useState(0);

  // UseState для отримання даних.
  const [products, setProducts] = useState([]);

  // Функція яка бігає на наш API, та бере дані із неї.
  const fetchProducts = () => {
    fetch("http://localhost:5157/product",
      {
      method: "GET"
    })
      .then((res) => {
        return res.json();
      })
      .then(data => {
        setProducts(data);
      })
  };

  // Вказується для форми, щоб форма не перезавантажувалася.
  const handleSubmit = (event) => {
    event.preventDefault();

    const product = { title: title, author: author, yearOfCreate: yearOfCreate, price: price };
    // Для відправки даних до нашого API
    fetch("http://localhost:5157/product",
      {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(product) // JSON.stringify(product) => перетворить об'єкт в JSON | JSON.parse("{id: 1, title: OneLove ...}") => перетворить файл в об'єкт.
      })
      .then(() => {
        console.log("New product added!");
        fetchProducts();
    })
  }

  // Викликаємо нашу функцію.
  useEffect(() => {
    fetchProducts()
  }, [])

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div>Title: <input type='text' value={title} onChange={(e) => {setTitle(e.target.value)}} /></div>
        <div>Author: <input type='text' value={author} onChange={(e) => {setAuthor(e.target.value)}}/></div>
        <div>Year of create: <input type="date" value={yearOfCreate} onChange={(e) => {setYearOfCreate(e.target.value)}} /></div>
        <div>Price: <input type='text' value={price} onChange={(e) => setPrice(e.target.value)}/></div>
        <button type="submit">Save</button>
      </form>
      {products.length > 0 &&
        <>
        {products.map(product => (
          <div key={product.id}>
            <div>Id: {product.id}</div>
            <div>Title: {product.title}</div>
            <div>Author: {product.author}</div>
            <div>YearOfCreate: {product.yearOfCreate}</div>
            <div>Price: {product.price}</div>
          </div>
        ))}
        </>
      }
    </>
  );
}

export default App;
