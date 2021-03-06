﻿import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar bg="primary" fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>TODO List</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='add circle' /> ADD Item
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='add circle' /> View Items
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
