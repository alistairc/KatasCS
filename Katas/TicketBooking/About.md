# Ticket Booking

A simple ticket booking system

- API to find and book tickets for a theatre

Simplifying assumptions:

- A single theatre, with a single layout. Same number of tickets for all shows
- No seat selection (unreserved, sit anywhere)
- Single entry price per show

Key Roles:

- Customer
- Box office manager

## Stories

As a potential customer  
I want to see which shows have seats available, and the cost  
So that I can decide if I want to book

As a box office manager  
I want to list which shows are when  
So that I can sell tickets

As a customer  
I want to buy a ticket  
So that I can go to the show

As a box office manager  
I want to see how many tickets have sold for each show  
So that I know how many people to expect, and which shows are selling weel or badly

## Notes

### Story 1: Customer: Which shows have tickets?

As a potential customer  
I want to see which shows have seats available, and the cost  
So that I can decide if I want to book

#### API design

GET /shows?dateFrom=2026-06-01&dateTo=2026-09-01

optional dates, default to next 12 months

200 OK

```json
{
    "shows": [
        {
            "name": "Macbeth",
            "performances": [
                {
                    "at": "2026-0602T20:00+01:00",
                    "available": 53
                }
            ]
        }
    ]
}
```

