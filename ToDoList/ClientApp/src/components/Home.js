import React, { Component,Form } from 'react';
import { Button,Alert, Row } from 'react-bootstrap'; 
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap.min.css';


export class Home extends Component {
  displayName = Home.name
  
 
  constructor(props)
  {
    super(props);
    this.state = {
      date: new Date(),
      texts : {
        welcomeText: 'Welcome Anoop',
        userName: 'You can add todo items with click of button'
      },name:'',
      description:'',
      category:'*Select Category*',
      priority:''
      
    };

    this.AddItem = this.AddItem.bind(this);
    this.handleChanges = this.handleChanges.bind(this);

  }

  handleChanges = (event) => {
    let fieldName = event.target.name;
    let fieldValue = event.target.value;
   console.log('Dropdown : '+event.target.selected);
    this.setState({
      [fieldName]: fieldValue
    });
    
    
  }

  AddItem(event) {
    console.log('Hey its done : '+this.state.priority);    
    event.preventDefault();

  }
   
 
  render() {
    return (
      <div>
        <div style={{marginTop:60}}>
        <Alert variant="success">
        <p>Welcome {this.state.texts.userName}</p>
        </Alert>
        </div>

<form onSubmit={this.AddItem}>
  <Row>
 <label>Item Name    
 <input type="text" name='name' value={this.state.name} onChange={this.handleChanges} />
  </label>
  </Row>
  <Row>
  <label>Priority  
  <select value={this.state.category} onChange={this.handleChanges} name='priority'>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
      </select>  </label>
  </Row>
  <Row>
  <label>Description  
  <input type="text" name='description' value={this.state.description} onChange={this.handleChanges} />
  </label>
  </Row>
  <Row>
  <label>Category  
  <select value={this.state.category} onChange={this.handleChanges}>
        <option value="Sports">Sports</option>
        <option value="Work">Work</option>
        <option value="Personal">Personal</option>
      </select>
  </label>
  </Row>
  <Row>
  <input type="submit" value="Submit" />
  </Row>
</form>
        </div>
    );
  }
}
