authnet\_processor
=
A simple and easy to use authnet processor for .net

todo
-

 1. Gateway => Interface to do common stuff
    
    ###manage customer information###
    - create\_customer\_profile 
    - create\_customer\_payment\_profile 
    - create\_customer\_shipping\_address 
    - get\_customer\_profile 
    - get\_customer\_payment\_profile 
    - get\_customer\_shipping\_address 
    - delete\_customer\_profile 
    - delete\_customer\_payment\_profile 
    - delete\_customer\_shipping\_address 
    - update\_customer\_profile 
    - update\_customer\_payment\_profile 
    - update\_customer\_shipping\_address 
    - create\_customer\_profile\_transaction 
    - validate\_customer\_payment\_profile 

    ###charge###
    - auth\_capture
    - auth\_only
    - capture\_only

    ###validation modes###
    - none
    - test
    - live

    ###supported credit cards###
    - visa
    - master
    - american\_express
    - discover
    

 2. Response => Consistent response types

 3. Allow use of *PaymentProfile* for capture, refund etc,.
