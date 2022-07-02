create or replace procedure Builds_UpdateOneById(_id int, _title text)
language plpgsql
as $$
begin
update Builds
SET title = _title
    WHERE Builds.build_id = _id;
end;$$;