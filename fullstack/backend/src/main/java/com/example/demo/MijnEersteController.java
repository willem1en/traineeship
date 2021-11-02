package com.example.demo;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@CrossOrigin(maxAge = 3600)
@RestController
public class MijnEersteController {
	
	@Autowired
	private IPersonRepository personRepository;
	
	@Autowired
	private IAddressRepository addressRepository;
	
	// Endpoint
	
	@RequestMapping("demo")
	public String demo() {
		return "Willemien";
	}

	@RequestMapping("personen")
	public List<Person> vindAllePersonen(@RequestParam String n) {
		return personRepository.findByNameStartsWith(n);
	}
	
	@RequestMapping(method = RequestMethod.POST, value="/api/person")
	public Person createPerson(@RequestBody Person p) {
		return personRepository.save(p);
	}
	
	@RequestMapping(method = RequestMethod.PUT, value="/api/person/{id}")
	public Person update(@PathVariable int id, @RequestBody Person p) {
		Person bestaandPerson = personRepository.findById(id).get();
		bestaandPerson.setName(p.getName());
		return personRepository.save(bestaandPerson);
	}
	
	@RequestMapping(method = RequestMethod.DELETE, value="/api/person/{id}")
	public void delete(@PathVariable int id) {
		Person bestaandPerson = personRepository.findById(id).get();
		personRepository.delete(bestaandPerson);
	}
	
	@RequestMapping(method = RequestMethod.POST, value="/api/address")
	public Address createAddress(@RequestBody Address a) {
		return addressRepository.save(a);
	}
	
	@RequestMapping(method = RequestMethod.PUT, value="/api/address/{id}")
	public Address updateAddress(@PathVariable int id, @RequestBody Address a) {
		Address address = addressRepository.findById(id).get();
		address.setStreetName(a.getStreetName());
		address.setHouseNumber(a.getHouseNumber());
		address.setPostCode(a.getPostCode());
		address.setCity(a.getCity());
		return addressRepository.save(address);
	}
	
	@RequestMapping(method = RequestMethod.DELETE, value="/api/address/{id}")
	public void deleteAddress(@PathVariable int id) {
		Address address = addressRepository.findById(id).get();
		addressRepository.delete(address);
	}
	
	@RequestMapping("adressen")
	public List<Address> vindAdresViaStraatNaam(@RequestParam(required = false, defaultValue = "") String a) {
		return addressRepository.findByStreetName(a);
	}
	
	@RequestMapping("alleadressen")
	public List<Address> vindAlleAdress() {
		return addressRepository.findAll();
	}
	
	@RequestMapping("eenadres/{id}")
	public Optional<Address> vindAlleAdress(@PathVariable int id) {
		return addressRepository.findById(id);
	}
	
	@RequestMapping("zoeken")
	public List<Address> vindEenAdres(@RequestParam(required = false, defaultValue = "") String n) {
		return addressRepository.findByStreetNameContaining(n);
	}
}
