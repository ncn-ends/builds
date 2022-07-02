create or replace procedure Builds_InsertOne(_title text)
language plpgsql
as $$
begin
    INSERT INTO Builds (title)
    VALUES (_title);
end;$$;