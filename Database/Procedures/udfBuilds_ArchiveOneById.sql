create or replace procedure Builds_ArchiveOneById(_id int)
language plpgsql
as $$
begin
    update Builds
    SET archived = true
    WHERE Builds.build_id = _id;
end;$$;