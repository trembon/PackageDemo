# PackageDemo

## Example requests

### Valid example request to create package
```
POST: /package
BODY:
{
  "weight": 15000,
  "length": 20,
  "height": 40,
  "width": 35
}
```

### Invalid example request to create package
```
POST: /package
BODY:
{
  "weight": 35000,
  "length": 65,
  "height": 97,
  "width": 72
}
```