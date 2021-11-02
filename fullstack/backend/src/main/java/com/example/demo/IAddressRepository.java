package com.example.demo;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

public interface IAddressRepository extends JpaRepository<Address, Integer> {
	
	List<Address> findByStreetName(String streetName);
	List<Address> findByStreetNameContaining(String input);

}
