Builder: Separate the construction of a complex object from its representation so that the same construction process can create different representations.

public async Task GivenACompanyHouseSearchClient_WhenSearchingForAOfficer()
{
    var fixture = new Fixture();
    Person person = fixture.Build<Person>()
                            .With(x => x.Name, "Bob")
                            .With(x => x.Id, 13)
                            .Create();

    var mockRepository = new Mock<IPersonRepository>();
    mockRepository.Setup(x => x.GetById(person.Id))
                    .Returns(person);

    IPersonRepository repository = mockRepository.Object;
}