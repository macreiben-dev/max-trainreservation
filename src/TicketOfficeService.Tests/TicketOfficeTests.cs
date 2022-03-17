using NFluent;
using System;
using System.Linq;
using Xunit;

namespace TicketOfficeService.Tests;

public class TicketOfficeTests
{
    [Fact]
    public void Should_fail_when_reservationRequest_is_null()
    {

        Check.ThatCode(() => new TicketOffice().MakeReservation(null))
            .Throws<ArgumentNullException>();
    }

    [Fact]
    public void Should_reserve_place_one_when_train_is_empty_and_trainHasOneCoach()
    {
        // ARRANGE
        string trainId = "someId";

        /**
         * This means I have to add a component that provides me a 
         * booking id, and later, call the webservice to retrieve one.
         * */
        string bookingId = "someBookingId";

        ReservationRequest request = new ReservationRequest(
            trainId, 1);

        // ACT
        TicketOffice target = new TicketOffice();

        var actual = target.MakeReservation(request);

        // ASSERT
        Check.That(actual.BookingId).IsEqualTo(bookingId);
        Check.That(actual.TrainId).IsEqualTo(trainId);
        Check.That(actual.Seats.First().Coach).IsEqualTo("1");
        Check.That(actual.Seats.First().SeatNumber).IsEqualTo(1);
    }
}