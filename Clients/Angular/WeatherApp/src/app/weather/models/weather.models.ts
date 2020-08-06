export class WeatherCoordDto {
    lon: number;
    lat: number;
}

export class WeatherInfoDto {
    id: number;
    main: string;
    description: string;
    icon: string;
}

export class WeatherMainDto {
    temp: number;
    pressure: number;
    humidity: number;
    tempMin: number;
    tempMax: number;
}

export class WeatherWindDto {
    speed: number;
    deg: number;
}

export class WeatherCloudsDto {
    all: number;
}

export class Sys {
    type: number;
    id: number;
    message: number;
    country: string;
    sunrise: number;
    sunset: number;
}

export class WeatherRootDto {
    coord: WeatherCoordDto;
    weather: WeatherInfoDto[];
    base: string;
    main: WeatherMainDto;
    visibility: number;
    wind: WeatherWindDto;
    clouds: WeatherCloudsDto;
    dt: number;
    sys: Sys;
    id: number;
    name: string;
    cod: number;
}
