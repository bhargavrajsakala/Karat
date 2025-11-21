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

      2nd case study:
