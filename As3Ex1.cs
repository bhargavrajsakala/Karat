1st case study:
private appconfig() constructor prevents instatiating appconfig from outside the class.
 public static AppConfig Instance : static property that returns singleton instnce,
if null lock enters block, inside lock it checks again if it was null
 * ncessary  to check because another thread might have created the instance while this thread waited.
  if still null _instance = new Appconfig(); creats the single instance and finally returns _instance.(purpose to create only 1instance)
   public static class HandlerFactory : factory that creats the crct Ihandler based on configuration.
     AppConfig.Instance.HandlerType; : go to global Appconfig obj and get the value of the handlertype setting.
    HandlerFactory.Create() : calls to get Ihandler instance
      handler.Handle("Welcome!"); : which performs the action(send msg to console).
main() calls HandlerFactory.Create()., create() access Appconfig.instance, 
instance sees _instance == null enters lockcreates new AppConfig() and sets handlertype.
 main() calls emailhandler.handle("welcome") and console prints msg.


      2nd case study:
_repo is a field. _repo is a reference to a repository that customerservice depends on.
 customer service method with interface type becasuse it depends in abstract methods.
 _repo = repo (_repo holds the reference to the repository implementation).
 then _repo becomes the injected repository instance (inmemorycustomerrepository)
 var customer = _repo.Get(id); ask repository to get customer with id.
 _repo is the instance that allows customerservice to access customer data.
services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>(); :
this registers InMemoryCustomerRepository as the implementation for ICustomerRepository
one instance of InMemoryCustomerRepository is created and reused for every request for ICustomerRepository
for entire life time. that why we prefer singleton.
 services.AddTransient<CustomerService>();
A new instance of customerservice is created every time we request customerservice.
 we prefer transient here  creating new instance is inexpensive.
   var repo = app.Services.GetRequiredService<ICustomerRepository>();
        repo.Add(new Customer { Id = 1, Name = "Alice" });
        repo.Add(new Customer { Id = 2, Name = "Bob" });
di container is assigning obj that implements ICustomerRepository earlier we registered this as singleton
singleton = one copy exists for hole app, now repo points to single shared repository obj
var service = app.Services.GetRequiredService<CustomerService>();
di gives customerservice instance , declared as transient
transient = a new obj is created every time
CustomerService constructor needs ICustomerRepository then di gives same singleton repo you created ealier
service is new CustomerService obj, but uses the same repo with data of alice and bob
printcustomer call _repo.get(1), it searches in _db for customer with id 1.

