using Xunit;

public class BruchTest
{
    // ===== TESTMETHODEN FÜR CONSTRUCTOR (STRING) =====

    /// <summary>
    /// Testet gültige Brüche im Format "Ganzzahl Zähler/Nenner"
    /// Es wird überprüft, ob die toString() Methode die gekürzte Form liefert
    /// </summary>
    [Fact]
    public void Constructor_ValidInput_ReturnsCorrectToString()
    {
        // Arrange & Act
        Bruch bruch = new Bruch("1 1/2");
        
        // Assert
        Assert.Equal("1 1/2", bruch.ToString());
    }

    [Fact]
    public void Constructor_WholeNumber_ReturnsOnlyGanz()
    {
        // Arrange & Act
        Bruch bruch = new Bruch("4 0/1");
        
        // Assert - sollte nur "4" sein, da Zähler 0 ist
        Assert.Equal("4", bruch.ToString());
    }

    [Fact]
    public void Constructor_ProperFraction_ReturnsMixedNumber()
    {
        // Arrange & Act
        Bruch bruch = new Bruch("2 1/2");
        
        // Assert
        Assert.Equal("2 1/2", bruch.ToString());
    }

    [Fact]
    public void Constructor_ImproperFraction_GetsCorrected()
    {
        // Arrange & Act
        // 0 3/2 sollte zu 1 1/2 gekürzt werden
        Bruch bruch = new Bruch("0 3/2");
        
        // Assert
        Assert.Equal("1 1/2", bruch.ToString());
    }

    [Fact]
    public void Constructor_FractionNeedsToBeShortened_ReturnsShortened()
    {
        // Arrange & Act
        // 0 2/4 sollte zu 0 1/2 gekürzt werden
        Bruch bruch = new Bruch("0 2/4");
        
        // Assert
        Assert.Equal("0 1/2", bruch.ToString());
    }

    [Fact]
    public void Constructor_LargeFractionNeedsToBeShortened_ReturnsShortened()
    {
        // Arrange & Act
        // 1 6/8 sollte zu 1 3/4 gekürzt werden
        Bruch bruch = new Bruch("1 6/8");
        
        // Assert
        Assert.Equal("1 3/4", bruch.ToString());
    }

    // ===== TESTMETHODEN FÜR EXCEPTION-HANDLING =====

    [Fact]
    public void Constructor_EmptyString_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Bruch(""));
    }

    [Fact]
    public void Constructor_NullString_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
#pragma warning disable CS8625
        Assert.Throws<ArgumentException>(() => new Bruch(null));
#pragma warning restore CS8625
    }

    [Fact]
    public void Constructor_MissingBruchPart_ThrowsFormatException()
    {
        // Arrange & Act & Assert
        // Nur Ganzzahl, kein Bruch
        Assert.Throws<FormatException>(() => new Bruch("1"));
    }

    [Fact]
    public void Constructor_InvalidGanzzahl_ThrowsFormatException()
    {
        // Arrange & Act & Assert
        // "abc" ist keine Ganzzahl
        Assert.Throws<FormatException>(() => new Bruch("abc 1/2"));
    }

    [Fact]
    public void Constructor_InvalidZaehler_ThrowsFormatException()
    {
        // Arrange & Act & Assert
        // "x" ist keine Ganzzahl für Zähler
        Assert.Throws<FormatException>(() => new Bruch("1 x/2"));
    }

    [Fact]
    public void Constructor_InvalidNenner_ThrowsFormatException()
    {
        // Arrange & Act & Assert
        // "y" ist keine Ganzzahl für Nenner
        Assert.Throws<FormatException>(() => new Bruch("1 1/y"));
    }

    [Fact]
    public void Constructor_NennerIsZero_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        // Nenner darf nicht 0 sein
        Assert.Throws<ArgumentException>(() => new Bruch("1 1/0"));
    }

    [Fact]
    public void Constructor_WrongFormat_MissingSlash_ThrowsFormatException()
    {
        // Arrange & Act & Assert
        // Format "1 2-3" statt "1 2/3"
        Assert.Throws<FormatException>(() => new Bruch("1 2-3"));
    }

    [Fact]
    public void Constructor_TooManyParts_ThrowsFormatException()
    {
        // Arrange & Act & Assert
        // Zu viele Teile im String
        Assert.Throws<FormatException>(() => new Bruch("1 2 3 4/5"));
    }

    // ===== TESTMETHODEN FÜR CONSTRUCTOR (INT, INT, INT) =====

    [Fact]
    public void Constructor_IntVersion_ValidInput_ReturnsCorrectToString()
    {
        // Arrange & Act
        Bruch bruch = new Bruch(1, 1, 2);
        
        // Assert
        Assert.Equal("1 1/2", bruch.ToString());
    }

    [Fact]
    public void Constructor_IntVersion_NennerIsZero_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Bruch(1, 1, 0));
    }

    [Fact]
    public void Constructor_IntVersion_ShortensCorrectly()
    {
        // Arrange & Act
        // 0 2/4 sollte zu 0 1/2 gekürzt werden
        Bruch bruch = new Bruch(0, 2, 4);
        
        // Assert
        Assert.Equal("0 1/2", bruch.ToString());
    }

    // ===== TESTMETHODEN FÜR ADDITION =====

    [Fact]
    public void Addiere_SimpleFractions_ReturnsCorrectSum()
    {
        // Arrange
        Bruch bruch1 = new Bruch("0 1/2");
        Bruch bruch2 = new Bruch("0 1/4");
        
        // Act
        Bruch summe = bruch1.addiere(bruch2);
        
        // Assert - 1/2 + 1/4 = 3/4
        Assert.Equal("0 3/4", summe.ToString());
    }

    [Fact]
    public void Addiere_MixedNumbers_ReturnsCorrectSum()
    {
        // Arrange
        Bruch bruch1 = new Bruch("1 1/2");
        Bruch bruch2 = new Bruch("2 1/2");
        
        // Act
        Bruch summe = bruch1.addiere(bruch2);
        
        // Assert - 1 1/2 + 2 1/2 = 4
        Assert.Equal("4", summe.ToString());
    }

    [Fact]
    public void Addiere_ComplexMixedNumbers_ReturnsCorrectSum()
    {
        // Arrange
        Bruch bruch1 = new Bruch("1 1/3");
        Bruch bruch2 = new Bruch("2 1/6");
        
        // Act
        Bruch summe = bruch1.addiere(bruch2);
        
        // Assert - 1 1/3 + 2 1/6 = 3 1/2
        Assert.Equal("3 1/2", summe.ToString());
    }

    [Fact]
    public void Addiere_WithZero_ReturnsOtherFraction()
    {
        // Arrange
        Bruch bruch1 = new Bruch("0 0/1");
        Bruch bruch2 = new Bruch("2 1/4");
        
        // Act
        Bruch summe = bruch1.addiere(bruch2);
        
        // Assert - 0 + 2 1/4 = 2 1/4
        Assert.Equal("2 1/4", summe.ToString());
    }

    // ===== TESTMETHODEN FÜR TOSTRING =====

    [Fact]
    public void ToString_OnlyZaehlerZero_ReturnsOnlyGanz()
    {
        // Arrange & Act
        Bruch bruch = new Bruch(5, 0, 1);
        
        // Assert
        Assert.Equal("5", bruch.ToString());
    }

    [Fact]
    public void ToString_MixedNumber_ReturnsCorrectFormat()
    {
        // Arrange & Act
        Bruch bruch = new Bruch(3, 1, 4);
        
        // Assert
        Assert.Equal("3 1/4", bruch.ToString());
    }

    [Fact]
    public void ToString_ProperFractionOnly_ReturnsWithZeroGanz()
    {
        // Arrange & Act
        Bruch bruch = new Bruch(0, 1, 3);
        
        // Assert
        Assert.Equal("0 1/3", bruch.ToString());
    }
}
