# UPSAPI v2
In response to the [UPS OAuth 2.0](https://www.ups.com/upsdeveloperkit?loc=en_US#:~:text=By%20June%202023%2C%20UPS%20will,and%20provide%20enhanced%20API%20capabilities.) requirement this assists the API transaction for UPS services

**Jeremy Heminger <jeremy.heminger@aqumor.com>, <contact@jeremyheminger.com>**

                      ᓚᘏᗢ

**Note :** *This library does not make API requests.* 
It abstracts data into simpler methods and parses JSON to be sent and received via REST. 
It does validate data and data types despite the UPS API only supporting strings.
*Currently this only supports the UPS Shipping and Adress Validation API(s)*

**Dependancies**
- :droplet: Newtonsoft.JSON
- :droplet: AQHelpers.dll

[Versions](./articles/version.html) 

[Documentation](./articles/documentation.html)

[Usage Examples](./articles/usage_examples.html)

[UPS API Reference Guide](https://developer.ups.com/api/reference)

[UPS Access Key to OAuth 2.0 Migration Guide](https://developer.ups.com/oauth-developer-guide)