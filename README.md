# **ResourcesManager.Services.ParkingPlaces**

## **Description**
* Resource Manager is a simple app which has functionality to book a company's resource, eg: parking place.

### **Architecture Overview**
* ToDo

### **User Stories**
* ToDo

## **Domain**
### **Location**
	* Name
	* Address
	* Resources<Resource, Quantity> -> Quantity - quantity of the available resources for reservation

### **Resource**
	* UniqueResourceIdentifier
	* Name - resource name, it could be parking place

### **User**
	* Username
	* Fullname
	* Email
	* Password
	* Salt
		
### **Reservation**
	* User
	* Resource
    * ResourceQuantity
	* Location
	* State
	* BeginDate
	* EndDate
	
### **ReservationState**
	* (enum: New, Completed, Cancelled)

## **Technologies:**
	* .NET5,