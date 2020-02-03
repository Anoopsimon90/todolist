import React, { Component,Form } from 'react';
import { Button,Alert, Row,Col } from 'react-bootstrap'; 
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
      priority:'',
      style: {
        border: "20px solid black"
    },
      
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
<div class="col-md-6 col-md-offset-3" style={this.style}> 
<form onSubmit={this.AddItem}>

  <Row>
  <Col xs="3">
 <label>Item Name    </label>
 </Col>

 <Col xs="3">

 <input type="text" name='name' value={this.state.name} onChange={this.handleChanges} />
 </Col>

  </Row>
  <Row>
  <Col xs="3">  <label>Priority  </label>  </Col>

  <Col xs="3">
  <select value={this.state.category} onChange={this.handleChanges} name='priority'>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
      </select>  
      </Col >

  </Row>
  <Row>
  <Col xs="3">

  <label>Description  </label>  </Col>
  <Col xs="3">
 <input type="text" name='description' value={this.state.description} onChange={this.handleChanges} />
 </Col>
  </Row>
  <Row>
  <Col xs="3">
  <label>Category  </label>
  </Col>
  <Col xs="3">
  <select value={this.state.category} onChange={this.handleChanges}>
        <option value="Sports">Sports</option>
        <option value="Work">Work</option>
        <option value="Personal">Personal</option>
      </select>
      </Col>
  </Row>
  <Row>
  <Col xs="3"/>

  <Col xs="3">
  <input type="submit" value="Submit" />
  </Col>
  </Row>
</form>
</div>
        </div>
    );
  }
}
